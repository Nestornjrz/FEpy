# WSL2

Todo esto es estando en un maquina con Windows 11 y con WSL2 habilitado.

Para saber si tenemos WSL2 habilitado podemos ejecutar el siguiente comando en el power shell

``` powershell
wsl -l -v
```

Estando en la raiz del power shell es decir sin haber entrado en ningun entorno
wsl, tenemos que ejecutar el siguiente comando para entrar en el entorno de por 
ejemplo Ubuntu, si lo tenemos instalado

``` powershell
wsl -d Ubuntu
```