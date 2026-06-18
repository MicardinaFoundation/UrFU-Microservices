pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }


        // stage('Backend - Build & Test ') {
        //     steps {
        //         dir('backend/') {
        //             echo 'Restoring backend dependencies...'
        //             sh 'dotnet restore First.sln'
                    
        //             echo 'Building C# backend solution...'
        //             sh 'dotnet build First.sln --configuration Release --no-restore'                    
        //         }
        //     }
        // }

        stage('Frontend - Install & Build') {
            steps {
                dir('frontend') {
                    echo 'Installing frontend dependencies...'
                    sh 'npm ci --silent'
                    
                    echo 'Running linter...'
                    sh 'npm run lint || true'
                    
                    echo 'Building React production bundle...'
                    sh 'npm run build'
                }
            }
        }


        // stage('Deploy') {
        //     when {
        //         branch 'main'
        //     }
        //     steps {
        //         echo 'Deploying application stack via Docker Compose...'
        //         sh "docker compose down --remove-orphans || true"
        //         sh "docker compose up -d"
        //     }
        // }

    }
    post {
        success {
            echo '✅ pipeline completed successfully!'
        }
        failure {
            echo '❌ Pipeline failed.'
        }
        always {
            cleanWs()
        }
    }

}