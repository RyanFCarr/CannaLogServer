## URLs
http://localhost:5080/swagger

## Run compose
Add `--build` to the `up` command whenever there are Server code changes to make it rebuild
`docker compose up -d`

Add `-v` to the `down` command to have it also remove any created volumes and start completely fresh. THIS WILL DELETED ALL DATA.
`docker compose down`

## ENV
### Mostly used by Docker build. Dev envs are set in launch settings
```
MYSQL_SOURCE=
MYSQL_DATABASE=
MYSQL_USER=
MYSQL_PASSWORD=
```