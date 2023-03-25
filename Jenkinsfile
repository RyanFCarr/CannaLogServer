pipeline {
	agent any
	
	stages {
		stage('Build') {
			steps {
                sh 'dotnet clean && dotnet build'
			}
		}
		stage('Test') {
            steps {
                echo 'Testing..'
            }
        }
        stage('Docker Build') {
		    when {
              expression {
                currentBuild.result == null || currentBuild.result == 'SUCCESS' 
              }
            }
            steps {
                sh 'docker build -t cannalog-server .'
            }
        }
	}
}