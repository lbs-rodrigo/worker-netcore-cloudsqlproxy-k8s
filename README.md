# worker-netcore-cloudsqlproxy-k8s

Encerramento do cloud_sql_proxy em container diferentes de um pod.

O exemplo considera que você esteja utilizando o Kubernets versão 1.0.0 ou superior 

## Descrição do Exemplo

- Projeto .NET 5.0 console com o processo de encerramento de processos 
- PodSpec para tornar a comunicação possível entre os containers

## Referencias

Compartilhamento entre Processos (Kubernets)

https://kubernetes.io/docs/tasks/configure-pod-container/share-process-namespace/

Exemplo de Spec do Pod

https://raw.githubusercontent.com/kubernetes/website/main/content/en/examples/pods/share-process-namespace.yaml
