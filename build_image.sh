#!/bin/bash

# Function to build the Docker image
build_image() {
  echo "Building Docker image..."
  docker build -t optechx-portal:dev -f Dockerfile.dev .
}

# Function to remove existing images by the specified tag
remove_existing_images() {
  echo "Removing existing Docker image (if any)..."
  docker rmi -f optechx-portal:dev 2>/dev/null || true
}

# Function to stop any running containers
stop_containers() {
  # Check if the "portal" container is running and stop it if it's running
  if docker ps -aq -f name=portal | grep -q .; then
    echo "Stopping 'portal' container..."
    docker stop portal >/dev/null 2>&1 || true
  fi

  # Check if the "ngrok" container is running and stop it if it's running
  if docker ps -aq -f name=ngrok | grep -q .; then
    echo "Stopping 'ngrok' container..."
    docker stop ngrok >/dev/null 2>&1 || true
  fi
}

# Function to handle errors and clean up
cleanup() {
  echo "Cleaning up..."

  # Removing any dangling containers (if any)
  docker ps -aq -f status=exited | xargs docker rm -v >/dev/null 2>&1 || true
}


# Main script
stop_containers
cleanup
remove_existing_images
build_image


echo "Docker image has been built successfully."
