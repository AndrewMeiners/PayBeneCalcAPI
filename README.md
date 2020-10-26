# PayBeneCalcAPI

This is an ASP.NET Web API built for the Paylocity code challenge

## To run and build -

The Benefits Web API is currently built to run on IIS Express and builds to a SQL Express Database called BenefitsDB

## Available APIs -

Currently available REST endpoints are served at
http://localhost:61285/api/Employee
and
http://localhost:61285/api/Dependent

An endpoint is available to calculate the cost of an Employee's benefits at the URL
http://localhost:61285/api/Employee/Cost/{id}
