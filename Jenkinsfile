pipeline {
    agent any
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }


        stage('Backend - Build & Test ') {
            steps {
                dir('backend/HeatBalanceSystem2') {
                    echo 'Restoring backend dependencies...'
                    sh 'dotnet restore HeatBalanceSystem.sln'
                    
                    echo 'Building C# backend solution...'
                    sh 'dotnet build HeatBalanceSystem.sln --configuration Release --no-restore'
                    
                    echo 'Running backend unit tests...'
                    sh 'dotnet test HeatBalance.Math.Tests/HeatBalance.Math.Tests.csproj --configuration Release --no-build'
                }
            }
        }

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


        stage('Deploy') {
            when {
                branch 'main'
            }
            steps {
                echo 'Deploying application stack via Docker Compose...'
                sh "docker compose down --remove-orphans || true"
                sh "docker compose up -d"
            }
        }

    }
}