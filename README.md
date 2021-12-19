[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Smtp.NET/blob/main/LICENSE.md)

# Smtp.NET
Simple library for sending utf-8 e-mails via smtp with .NET

# Installation
```bash
dotnet add package Smtp --version 1.0.0
```

```c#
using Smtp;

var smtp = new Smtp();
smtp.SetHost("smtp host");
smtp.SetPort(587);
smtp.SetUsername("smtp username");
smtp.SetPassword("smtp password");
smtp.Mail(new MailAddress("sender mail address", "sender display name"), new MailAddress("recipient mail address", "recipient display name"), "mail subject", "mail content");
```
