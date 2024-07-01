
# Comandos de Git

Para forzar un push en la l�nea de comandos, especialmente despu�s de haber realizado un squash de commits, puedes usar el siguiente comando:

``` powershell
 git push origin <nombre-de-tu-rama> --force-with-lease
```

> *<u>Importante</u>*: Forzar un push (--force) reemplazar� el historial en el repositorio remoto con tu historial local. Esto puede causar problemas para otros colaboradores que est�n trabajando en la misma rama. Es recomendable comunicarse con el equipo antes de realizar esta acci�n. La opci�n --force-with-lease es m�s segura ya que verifica si hay cambios en el repositorio remoto antes de sobrescribirlos.