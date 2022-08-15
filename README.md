# ViberBot

## How to run
1) You need to create Viber Bot and get Viber Auth Token. Create bot you can here https://partners.viber.com/account/create-bot-account
2) Then you need to insert token to the app. Open ViberBot/Properties/launchSettings.json and insert in front of VIBER_AUTH_TOKEN your token
3) Run your MSSQL server and insert your data in front of CONNECTION_STRING
4) You should use ngrok to connect to app or your own domen if you publish this app. For ngrok you need to download from official web page and insert command ngrok.exe http 5000. Your public ip insert in the next step
5) You need to use postman or other API platforms to make one request. Open postman and make this request
* url : https://chatapi.viber.com/pa/set_webhook
* Open Headers and type KEY: X-Viber-Auth-Token, VALUE: *your token* e.g. 123412341234-12412341243-123412341234
* Open Body => raw => Text to JSON and insert this JSON file. In front of url insert your public ip and in the end type /Viber
```json
{
    "url": "https://a1b2-255-255-255-255.eu.ngrok.io/Viber",
    "event_types": [
        "failed",
        "subscribed"
    ]
}
```
or you can import this cURL
```
curl --location --request GET 'https://chatapi.viber.com/pa/set_webhook' \
--header 'X-Viber-Auth-Token: 123412341234-12412341243-123412341234' \
--header 'Content-Type: application/json' \
--data-raw '{
    "url": "https://a1b2-255-255-255-255.eu.ngrok.io/Viber",
    "event_types": [
        "failed",
        "subscribed"
    ]
}'
```
6) Type in cmd dotnet database update
7) Run an app
