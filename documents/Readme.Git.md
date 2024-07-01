
# Comandos de Git

Para forzar un push en la línea de comandos, especialmente después de haber realizado un squash de commits, puedes usar el siguiente comando:

``` powershell
 git push origin <nombre-de-tu-rama> --force-with-lease
```

> *<u>Importante</u>*: Forzar un push (--force) reemplazará el historial en el repositorio remoto con tu historial local. Esto puede causar problemas para otros colaboradores que estén trabajando en la misma rama. Es recomendable comunicarse con el equipo antes de realizar esta acción. La opción --force-with-lease es más segura ya que verifica si hay cambios en el repositorio remoto antes de sobrescribirlos.