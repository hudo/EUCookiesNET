# What's this?

Small .NET utility for displaying a user warning about using of cookies on the site (tested with ASP.NET MVC, but should work on any framework). Inspired by https://github.com/infinum/cookies_eu (that's were css and js scripts come from, thanx guys)!

# Installation

Install via [Nuget](https://www.nuget.org/packages/EUCookies.NET/)

First include JS and CSS files in header, bottom of the body or in the Bundle config:

    <link href="~/Content/cookies_eu.css" rel="stylesheet" />
    <script src="~/Scripts/jquery-2.0.3.js"></script>
    <script src="~/Scripts/jquery.cookie.js"></script>
    <script src="~/Scripts/cookies_eu.js"></script>
    

Then, simply call this line to inject a necessery HTML:

    @Html.Raw(Consent.Instance.Install())


that's it! There are some options on Install method, so you can override default text.


## Localization

You can use the Install() method optional parameters to set HTML text manually, but the project contains localized resource files, currently for English and Croatian language. Please feel free to contribute with your language resource file!


    