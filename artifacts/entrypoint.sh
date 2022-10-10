#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:5188"

until dotnet ef database update; do
  >&2 echo "Database restored"
  sleep 1
  done 

>&2 echo "Starting autodock-api application."
exec $run_cmd
