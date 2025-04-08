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

## Facciones
* Los personajes pueden pertenecer a una o más facciones
* Los personajes nuevos no pertenecen a ninguna facción.
* Un personaje puede unirse o abandonar una o más facciones.
* Los jugadores que pertenezcan a la misma facción son considerados aliados.
* Los aliados pueden curarse entre si.
* Los aliados no pueden hacerse daño entre si.

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
- [X] Debe permitir crear un personaje y su nivel inicial debe ser 1.
- [X] Debe arrojar una excepción si un personaje muerto intenta subir de nivel.
- [X] Debe evitar que un personaje se cure más de lo que su nivel actual le permite.
- [X] Debe la vida actual del personaje ser 500 cuando su vida maxima es 1000 recibe un ataque de 800 y se cura 300.
- [X] Debe un personaje poder subir de nivel y al alcanzar el nivel 6, su vida máxima debe aumentar a 1500.
- [X] Debe un personaje tener 1200 de vida cuando recibe un ataque de 700 y se cura 400 y es nivel 6
- [X] Debe disminuir el daño de ataque de un personaje en un 50% si el personaje al que ataca lo supera por 5 niveles o más.
- [X] Debe aumentar el daño de ataque de un personaje en un 50% si el personaje al que ataca es inferior por 5 niveles o más.
--------------------------------------------
- [X] Debe permitir crear un personaje sin facción.
- [X] Debe permitir que un personaje pertenezca a una facción.
- [X] Debe permitir que un personaje pertenezca a más de una facción.
- [ ] Debe permitir que un personaje abandone una facción.
- [ ] Debe arrojar una excepción cuando un personaje intente abandonar una facción a la que no pertenece.
- [ ] Debe permitir que un personaje abandone varias facciones.
- [ ] Debe arrojar una excepcion cuando personajes pertenecientes a una misma facción intenten atacarse.
- [ ] Debe permitir que personajes de la misma facción se curen.
- [ ] Debe arrojar una excepción cuando un jugador intente curar a otro personaje que no pertenece a su facción.