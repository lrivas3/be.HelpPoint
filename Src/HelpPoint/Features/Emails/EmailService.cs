using System.Net;
using HelpPoint.Common.Errors.Exceptions;
using HelpPoint.Config;
using HelpPoint.Infrastructure.Dtos.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace HelpPoint.Features.Emails;

public class EmailService(IOptions<EmailSettings> settings) : IEmailService
{
    private readonly EmailSettings _settings = settings.Value;

    public async Task<bool> SendEmailAsync(EmailDto request)
    {
        if (request.To is null or "")
        {
            throw new BadRequestCustomException("Destinatario no encontrado en peticion");
        }

        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_settings.UserName));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;

        var builder = new BodyBuilder { HtmlBody = request.HtmlBody };

        // embed headerImage.png as <img src="cid:headerImage">
        var headerImagePath = Path.Combine("Templates", "headerImage.png");
        if (!File.Exists(headerImagePath))
        {
            throw new FileNotFoundException($"Email no enviado. No se encontró '{headerImagePath}'");
        }

        if (builder.LinkedResources != null)
        {
            var headerResource = builder.LinkedResources.Add(headerImagePath);
            headerResource.ContentId = "headerImage";
        }

        // embed logoImage.png as <img src="cid:logoImage">
        var logoImagePath = Path.Combine("Templates", "logoImage.png");
        if (!File.Exists(logoImagePath))
        {
            throw new FileNotFoundException($"Email no enviado. No se encontró '{logoImagePath}'");
        }

        if (builder.LinkedResources != null)
        {
            var logoResource = builder.LinkedResources.Add(logoImagePath);
            logoResource.ContentId = "logoImage";
        }

        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);

        if (smtp.Timeout != 0)
        {
            smtp.Timeout = _settings.TimeOut;
        }

        await smtp.AuthenticateAsync(_settings.UserName, _settings.PassWord);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);

        return true;
    }
}
