# Docker can run containers
# Docker containers are instances of Docker images
#   (similar to how objects are instances of classes)
#   (Docker image is to Docker container as VM image is to VM instance)

# to make an image, you need some base image
#  and a Dockerfile, which has the instructions to make a new image
#  from a base image

# basic overall tasks for your Dockerfile:
#    1. identify a good base image (balance between official support /
#           popularity and already having all your deps)
#    2. install your extra dependencies into the image
#    3. install your app
#    4. tell Docker how to start your app from this image.


#         registry           repo/name     tag
#            v                   v          v
FROM mcr.microsoft.com/dotnet/core/runtime:3.0

# WORKDIR command: like "cd", except will create the folder if necessary
WORKDIR /app

# COPY command:
#  first arg: a relative path from the build context (usually the
#      same as the Dockerfile's folder) of what files we need to copy in
#  second arg: where in the image's file system to copy them to.
COPY publish/ ./

# CMD command:
#   this tells Docker what command to run on a new container to start it
CMD ["dotnet", "ContainerizedConsole.dll"]

# before build:
#     dotnet publish -c Release -o publish
# building the image:
#     docker build -t console1 .
# running a container:
#     docker run console1
