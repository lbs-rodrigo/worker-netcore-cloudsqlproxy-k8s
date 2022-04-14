# Worker, Net5.0, Cloud SQL Proxy e Kubernets

Encerramento do cloud_sql_proxy a partir de uma aplicação .NET executada no kubernets a spec CronJob

O exemplo considera que você tenha familiaridade com .NET, Docker, Kubernets e Cloud SQL Proxy

## Folders

- deploy: contem os arquivos para implantação 
    - Dockerfile: cria o container do worker
    - k8s-worker-spec: implanta o worker e o cloud_sql_proxy no cronjob do k8s

- src: contem o exemplo que demonstra a finalização do processo do cloud_sql_proxy

## Sobre o exemplo

O Worker irá aguardar 2 minutos exemplificando a execução de uma regra de negocio, apos os 2 minutos irá iniciar a finalização do container cloud_sql_proxy e por fim finalizar o seu proprio processo.

## Referencias

Compartilhamento entre Processos (Kubernets)

https://kubernetes.io/docs/tasks/configure-pod-container/share-process-namespace/

Exemplo de Spec do Pod

https://raw.githubusercontent.com/kubernetes/website/main/content/en/examples/pods/share-process-namespace.yaml
