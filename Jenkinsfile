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
                sh 'openssl pkcs12 -export -inkey ../../.env/https/cannalog/privkey.pem -in ../../.env/https/cannalog/fullchain.pem -name aspnetapp -out ../../.env/https/cannalog/aspnetapp.pfx'
                withEnv(readFile('../../.env/cannaLogServer.prod.env').split('\n') as List) {
                    sh 'docker-compose --profile prod up -d'
                }
            }
        }
	}
}