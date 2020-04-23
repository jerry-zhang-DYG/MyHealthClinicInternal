#My Health Clinic For Debug

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

The MyHealth app is already configured to use this instance.

## Kubernetes Quickstart
The following will use a local Docker/Kubernetes installation to SQL and this web app

### 1. Create a Kubernetes Secret
The deployment uses a secret to inject the SQL configuration and password into the containers. Simply create the secret, using a password of your choice:

```kubectl create secret generic mhc-database --from-literal=password='SomePass123@@@' --from-literal=connection='Server=tcp:mhc-sql;Initial Catalog=mhcdb;Persist Security Info=False;User ID=sa;Password=SomePass123@@@;MultipleActiveResultSets=False;TrustServerCertificate=True;Connection Timeout=30;'```

Note there are two keys in this secret: password and connection.

### 2. Build the images (local)
If you don't already have a copy of the images locally:

```docker-compose build```

### 3. Create the Kubernetes Deployment
The mhc-sql-local.yaml file deployes the two containers and two services:
* mhc-front (Deployment): Front end pod serving the web application
* mhc-sql (Deployment): SQL Server in a Linux Container
* mhc-front (Service): Load balanced service hosting the web app in port 80
* mhc-sql (Service): Cluster-only (internal) service hosting SQL on port 1433

### 4. TEST
You should be able to reach the web application on http://localhost

### Teardown
Simply delete each item that got created above:

```
kubectl delete deployment mhc-front
kubectl delete deployment mhc-sql
kubectl delete service mhc-front
kubectl delete service mhc-sql
```

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

