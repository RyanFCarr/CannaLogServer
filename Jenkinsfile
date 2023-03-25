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
        stage('Deploy') {
		    when {
              expression {
                currentBuild.result == null || currentBuild.result == 'SUCCESS' 
              }
            }
            steps {
                withEnv(readFile('../../.env/cannalog-server.env').split('\n') as List) {
                    sh 'docker build -t cannalog-server .'
                }
            }
        }
	}
}