# What's this?

Small .NET utility for displaying an user waring about using of cookies on the site (ASP.NET MVC, WebForms). Inspired by https://github.com/infinum/cookies_eu (that's were css and js scripts come from, thanx guys)!

# Installation

Install via Nuget.  

First include JS and CSS files in header, bottom of body or in Bundle config:

    <link href="~/Content/cookies_eu.css" rel="stylesheet" />
    <script src="~/Scripts/jquery-2.0.3.js"></script>
    <script src="~/Scripts/jquery.cookie.js"></script>
    <script src="~/Scripts/cookies_eu.js"></script>
    

Then, simply call this line to inject necessery HTML:

    @Html.Raw(Consent.Instance.Install())


that's it! There are some options on Install method, so you can override default text.


    