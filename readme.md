## URLs
http://localhost:5080/swagger
https://localhost:5443/swagger

## Run compose
`docker compose --profile dev up -d --build`

## For Dev ssl certificate
### Replace \$CREDENTIAL\_PLACEHOLDER\$ with a password. This password needs to go in the ENV
```
dotnet dev-certs https -ep "$env:USERPROFILE\.aspnet\https\aspnetapp.pfx"  -p $CREDENTIAL_PLACEHOLDER$
dotnet dev-certs https --trust
```

## ENV
```
MYSQL_SOURCE=
MYSQL_DB=
MYSQL_USER=
MYSQL_PW=
ASPNETCORE_URLS=https://+:443;http://+:80 #This one is shared
KESTREL_CERTIFICATE_PASSWORD=
```