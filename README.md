# AnalyticsEvents-CSharp-Example

A DotNetcore example code on how to send data to the custom analytics schema using the Analytics API

## Steps: 
1. Clone this repo
2. Create your schema
3. Update the following variables in Program.cs. It's recommended that you read these values from a property file in the real implementation. 

     ```
     var appd_key = "KEY";
     var appd_account_name = "AccountName";
     var app_schema = "analytics_orders";
     var analytics_endpoint = "https://fra-ana-api.saas.appdynamics.com/events/publish/";
     ````
 3. Build and run 
 
# Expected output

```
########## Request Header ##########
Date: Tue, 20 Oct 2020 11:25:54 GMT
Frame-Options: DENY
Server: openresty/1.15.8.1
X-Content-Security-Policy: default-src 'self'
X-Content-Type-Options: nosniff
X-Frame-Options: DENY
X-XSS-Protection: 0
Connection: keep-alive

########## Response Code ##########
OK
####################################
Successfully sent custom data to AppD 
[ {"price":100.0,"amount":80,"assets":"Mr.IO","order_date":"2020-10-20T11:25:52.729363Z","subscribers":20}]
```

# Reference 
https://docs.appdynamics.com/display/PRO45/Analytics+Events+API
