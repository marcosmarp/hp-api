# Harry Potter API

## Docs
##### [Use Swagger to test the API!](https://hp-api-marcosmarp.herokuapp.com/swagger/index.html)
### Get all characters (basic data)
#### Make a `GET` request to `https://hp-api-marcosmarp.herokuapp.com/api/characters`
#### You can filter the list through `name`, `gender`, `house`, `isWizard`, `isHogwartsStudent`, `isHogwartsStaff`, `isAlive` properties adding them to the GET query parameters
#### For example, `https://hp-api-marcosmarp.herokuapp.com/api/characters?name=Weasley&isAlive=true` will only return the Weasley alive characters
### Get a character by ID (detailed data)
#### Make a `GET` request to `https://hp-api-marcosmarp.herokuapp.com/api/characters/{id}`
#### For example, `https://hp-api-marcosmarp.herokuapp.com/api/characters/60be073e-2f67-416c-a87d-c9b0a8129261` will return the Harry Potter data.

## What's this?
### Harry Potter API is REST API developed over .NET CORE 6 to get information about every character on the Harry Potter world.

## Where the data came from?
### I blatantly stoled it from [Beth Fraser's hp-api](https://github.com/bethfraser/hp-api), there you can see who uploaded what.
## So, what's different between this API and Beth Fraser's one?

### This API has a filtering and detailed-view system for retrieving the characters and the data in general; besides that, I'm open to suggestions to what can we do to improve it

## What's the stack of this project?
### This project is developed on Microsoft's .NET CORE 6 framework with a PostgreSQL database hosted in heroku managed through Entity Framework. The app is currently running on a Docker container in Heroku.

## Contributions
### Feel free to suggest anything through an issue

## License
### MIT

## Support the project
### You can donate through [Paypal](https://www.paypal.com/donate/?hosted_button_id=59F5WUQQ7T6TG&sdkMeta=eyJ1cmwiOiJodHRwczovL3d3dy5wYXlwYWxvYmplY3RzLmNvbS9kb25hdGUvc2RrL2RvbmF0ZS1zZGsuanMiLCJhdHRycyI6eyJkYXRhLXVpZCI6IjkxNmZiODRhYjNfbWRtNm1kZzZtanUifX0&targetMeta=eyJ6b2lkVmVyc2lvbiI6IjlfMF81OCIsInRhcmdldCI6IkRPTkFURSIsInNka1ZlcnNpb24iOiIwLjguMCJ9)
