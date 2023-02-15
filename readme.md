## For Dev ssl certificat
```
dotnet dev-certs https -ep "$env:USERPROFILE\.aspnet\https\aspnetapp.pfx"  -p $CREDENTIAL_PLACEHOLDER$
dotnet dev-certs https --trust
```

## Run compose
`docker compose --profile dev up -d --build`

## ENV
```
MYSQL_SOURCE=
MYSQL_DB=
MYSQL_USER=
MYSQL_PW=
ASPNETCORE_URLS=https://+:443;http://+:80 #This one is shared
KESTREL_CERTIFICATE_PASSWORD=
```