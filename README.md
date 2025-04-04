# KATA
https://sammancoaching.org/kata_descriptions/rpg_combat.html

## Definiciones
### Daño y salud
* Todos los personajes son creados con 1000 de vida y vivos. Pueden estar vivos o muertos.
* Los personajes pueden realizar daño a otros
* Cuando un personaje recibe daño y su vida llega a 0, el personaje muere.
* Un personaje no debe hacerse daño a si mismo.
* Un personaje puede curarse a si mismo.
* Los personajes muertos no pueden curarse.

### Niveles
* Todos los personajes empiezan en el nivel 1.
* La vida máxima de los personajes es de 1000, una vez alcacen el nivel 6 su vida máxima incrementa a 1500.
* Si el objetivo del ataque de un personaje es otro 5 o más niveles por encima, el daño del ataque se reduce en un 50%.
* Si el objetivo del ataque de un personaje es otro personaje 5 o más niveles por debajo, el daño del ataque aumenta en un 50%.

## Test list
- [X] Debe permitir crear un personaje con 1000 puntos de vida y en estado vivo.
- [X] Debe un personaje infligir daño a otro personaje y reducir su vida en la cantidad del daño.
- [X] Debe un personaje morir si recibe un ataque mayor a su vida actual.
- [X] Debe cambiar el estado de un personaje a muerto cuando su vida es igual o menor a 0.
- [X] Debe evitar que un personaje se haga daño a si mismo.
- [X] Debe poder curarse a sí mismo si está vivo.
- [X] Debe arrojar una excepcion si un personaje muerto intenta curarse.
- [X] Debe aumentar su vida en la cantidad curada al curarse a sí mismo.
---------------------------------------------

