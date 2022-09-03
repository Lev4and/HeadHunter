#!/bin/sh
#!/usr/bin/env bash
which sh
cd /var/
mkdir projects
cd projects
git clone https://github.com/Lev4and/HeadHunter.git
cd HeadHunter
git reset --hard origin/master
rm .env
cp .env.dist .env
export $(egrep -v '^#' .env | xargs -0)
docker swarm init
docker stack deploy -c docker-compose.yml headhunter --prune --with-registry-auth