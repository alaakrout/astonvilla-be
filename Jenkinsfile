pipeline {
    agent any
    environment {
        IMAGE_NAME        = "astonvilla-be"
        DOCKER_HUB_USER   = "akrout97"
    }
    
    options {
        buildDiscarder(logRotator(numToKeepStr: '3'))
    }

    stages {


        stage('Build Docker Image') {
            steps {
                bat "docker build -t ${IMAGE_NAME} -f DEvOps/Dockerfile ."
            }
        }

        stage('Push Docker Image to registry'){
          steps{
              withCredentials([usernamePassword(credentialsId: 'docker_registry', passwordVariable: 'password', usernameVariable: 'username')]) {
                bat "docker login -u $username -p $password"
                bat "docker tag ${IMAGE_NAME} ${DOCKER_HUB_USER}/${IMAGE_NAME}"
                bat "docker push ${DOCKER_HUB_USER}/${IMAGE_NAME}"
              }
          }
        }

        stage('Clean up'){
          steps{
              bat "docker rmi ${IMAGE_NAME} ${DOCKER_HUB_USER}/${IMAGE_NAME}"
              }
          }

        stage ('deploy app to minikube'){

           steps{
                withKubeConfig([credentialsId: 'kubeconfig', serverUrl: 'https://127.0.0.1:65265']) {
                  bat 'kubectl apply -f astonvilla-be.yaml'
                }
           }
        }
    }
}

