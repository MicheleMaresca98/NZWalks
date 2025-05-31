# NZWalks

## How to run
* Launch database:
```shell
docker run -p 3308:3306 --name nzwalksdb -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=nzwalksdb -d mysql
```

* Apply migrations:
```shell
dotnet tool run dotnet-ef database update
```