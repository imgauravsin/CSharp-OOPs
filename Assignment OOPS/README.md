### Exercise 1: Our client is an equipment owner company. It needs a system to manage its equipment inventory (CRUD on equipment). 

```
Equipment has following details in common -
1.	Name
2.	Description
3.	Distance Moved Till Date (Defaults to 0 km)
4.	Maintenance Cost (Defaults to 0)
5.	Type of equipment – Use enum to represent this value

Equipment should have following functionality in common
1.	Move By – This functionality is to move equipment by certain distance (in km). It should take the distance to move as parameter. This in turn cause the following
a.	Increase the “distance moved till date” by the distance equipment is made to move.
b.	Increases the “maintenance cost” – This depends on the kind of equipment. (Think Inheritance & Polymorphism)

All equipment is one of the following two kinds -
1.	Mobile – This equipment can move around by itself (it has wheels) e.g. a JCB, a Jeep, a tractor etc. 
Mobile equipment has following specific details
a.	Number of wheels
b.	When they are moved around (via Move By method), the maintenance cost increases by (numberOfWheels * distanceMoved)

2.	Immobile – This equipment must be carried around e.g. a trolley, a ladder etc.
Immobile equipment has following specific details
a.	Weight
b.	When they are moved around (via Move By method), the maintenance cost increases by (weight * distance moved)

The application being created should fulfill the following requirements.
1.	Create an equipment – mobile and immobile
2.	Move an equipment – mobile and immobile (this is going to update certain properties in equipment)
3.	Show details of an equipment. (all details – including distance moved till date and maintenance cost)

Use following keywords: virtual, override, abstract etc
User following concepts: class, abstract, inheritance, polymorphism etc. 

```

### Exercise 2: This assignment is supposed to make you practice your skills on interfaces, classes and OOPs.
```
Story -
The system is a duck simulation game. There are ducks, each having weight and number of wings. All ducks can fly and quack, but different type of ducks fly and quack differently. For instance, let us consider the following–
1.	Rubber ducks don’t fly and squeak.
2.	Mallard ducks fly fast and quack loud.
3.	Redhead ducks fly slow and quack mild.
All ducks have following common property:
Type of Duck – Use enum to represent this value
Design classes and interfaces for the above story to meet the following requirements -
a.	Create a duck
b.	Show details of a duck, i.e. when you call for e.g. ShowDetails() method of a duck, duck should print its traits.
User following concepts: class, interfaces, polymorphism etc.
```
