# _Automatic Question Texter_

#### _*Use Twilio to automatically text yourself questions at intervals that you set*, October 6th, 2016_

#### By _**Wolfgang Warneke**_

## Description

_Have you ever found yourself in a situation where you wanted to get text-bombed with study questions so you can prepare for something like, oh say, a job interview?  Well, we've got you covered.  Use this ASP.Net Core console app to receive however many random questions from your own question bank at whichever interval of minutes you desire._

## Setup/Installation Requirements

* _Set up a database in SQL server with a table called `Question` with nvarchar columns `question` and `category`.
* _Set your Database name in EnvironmentVariables.cs_
* _Confingure your Twilio account information in EnvironmentVariables.cs_
* _Add questions to your database manually or by running our example questions (***not yet implemented***)_
* _Run it_
* _Enjoy_

_Check back later, we will add SQL commands to seed a stock database_

## Known Bugs

_User is unable to add more than one question in a console session.  :(_

## Support and contact details

_Reach out to me on social media @WolfgangWarneke_

## Technologies Used

_ASP.Net Core, Entity Framework Core, SQL Server, Twilio API_

### License

Copyright (c) 2016 **_Wolfgang Warneke_**
