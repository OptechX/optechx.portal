#!/usr/bin/env zsh

# Check if the "ngrok" network exists
if ! docker network inspect ngrok &>/dev/null; then
  # If the network doesn't exist, create it
  echo "Creating 'ngrok' network..."
  docker network create ngrok
else
  echo "'ngrok' network already exists."
fi

# Function to start the Docker container
start_container() {
  echo "Starting Docker container..."
  docker run --rm --detach \
  --name portal \
  --network ngrok \
  optechx-portal:dev >/dev/null 2>&1
}

# Function to stop the Docker container if it's running
stop_container() {
  echo "Stopping the running container (if any)..."
  docker stop portal >/dev/null 2>&1 || true
}

# Function to remove any dangling or leftover containers
cleanup_containers() {
  echo "Cleaning up dangling or leftover containers..."
  docker ps -aq -f status=exited | xargs docker rm -v >/dev/null 2>&1 || true
}

# Main script
cleanup_containers
stop_container
start_container

# Start ngrok
docker run --rm --detach \
--name ngrok \
--network ngrok \
-v $(pwd)/ngrok.yaml:/etc/ngrok.yaml \
-e NGROK_CONFIG=/etc/ngrok.yaml \
ngrok/ngrok:alpine \
start --all
