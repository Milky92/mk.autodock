#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:5188"

until dotnet ef database update --project AD.Persistence.DataAccess -s AD.APi; do
>&2 echo "SQL Server is starting up"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd