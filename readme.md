#My Health Clinic

## Docker Compose Quickstart
The following will run a SQL Server container and an instance of the web application.
1. Ensure you have Docker up and running
2. Ensure you have installed Docker Compose
3. Open a terminal/shell to the root folder of this solutio0n
4. Run: ```docker-compose up```
5. Open a web browser and test http://localhost

The following will run _only_ a SQL container:
1. Ensure you have Docker up and running
2. Ensure you have installed Docker Compose
3. Open a terminal/shell to the root folder of this solutio0n
4. Run: ```docker-compose -f docker-compose-sql.yml up```

The MyHealth app is alreadyu configured to use this instance.

## Overview
My Health Clinic, a sample application built for demo and training purposes, is for a fictious health care provider **HealthClinic.biz**. 
HealthClinic.biz uses different Microsoft and multi-channel apps built with Visual Studio and Azure to grow their business and modernize their customer experience. 
They also innovate and offer multiple apps and services—including websites, mobile apps, and wearable apps—to empower their patient’s well-being with easy access to manage their healthcare data and stay healthy.

**Note:** The code has been modified from the original version. The mobile (Xamarin and Cordova) projects have been removed and the web project has been upgraded to work in Visual Studio 2017.      
You can find the old, original code on this [GitHub repo](https://github.com/Microsoft/HealthClinic.biz)

![](mhc-dashboard.png)

## Prerequisites
* Visual Studio 2017 
* Bower extension for Visual Studio Team Services 
* An active Azure subscription 

## Blogs posts

Here's links to blog posts related to this project:

[Connect(“demos”);](http://blogs.msdn.com/b/visualstudio/archive/2015/12/08/connect-demos-2015-healthclinic-biz.aspx) // 2015: HealthClinic.biz by Erika Ehrli
[ASP.NET 5 and .NET Core RC1 in context Plus all the Connect 2015]http://www.hanselman.com/blog/ASPNET5AndNETCoreRC1InContextPlusAllTheConnect2015News.aspx News by Scott Hanselman

## Licenses

This project uses some third-party assets with a license that requires attribution:

Roboto Font: by [Christian Robertson](https://plus.google.com/110879635926653430880/about) ([Roboto at Google Fonts](https://fonts.google.com/specimen/Roboto))
Raleway Font: by Matt McInerney, Pablo Impallari, Rodrigo Fuenzalida and by Igino Marini ([Raleway at Google Fonts](https://www.google.com/fonts/specimen/Raleway))
For additional information about the licenses, please see the dependency repositories.

