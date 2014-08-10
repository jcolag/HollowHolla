HollowHolla
===========

_Hollow Holla_ is a social networking mock-up framework.

Every once in a while, I have an idea for a project that would be nicely presented as if it were a social networking site, but not a real site.

So, I'm making one.

This application should be a viable stand-in for a user activity feed that could easily be any similar website.

Usage
=====

In the `Content` folder, there is a file named `play.txt`.  This is a simple flat-file database of lines from a play (the example is **The Bicyclers**, by John Kendrick Bangs), formatted as the following fields, delimited by a `#`.  One hopes it stays relatively rare in dramatic works.

 - **The Speaker**, generally the name.

 - **Stage Direction**, optional.

 - **The Line** to be delivered.

The three pieces are parsed and formatted as if they were posted on a social network.

Note that the script of **The Bicyclers** may have additional stage directions within the lines.  It was generated from an HTML file [from Project Gutenberg](https://www.gutenberg.org/ebooks/11759).

These lines are then served to the browser, one at a time, and processed as new posts.  Eventually, they will be timestamped for better elaboration.

Configuration
-------------

If there is need for multiple plays, the `GetPlay()` method called by `Index()` takes a filename as a parameter, which overrides `Content/play.txt`.

Credits
=======

The interface is built on [Twitter Bootstrap](http://getbootstrap.com/) v2.3.2 and uses [normalize.css](http://necolas.github.com/normalize.css/3.0.1/normalize.css) v3.0.1, both used under an MIT Public License.  It also uses Dave Gandy's [Font Awesome](http://fontawesome.io) under the terms of the [SIL OFL 1.1](http://scripts.sil.org/OFL) and CSS code under an MIT Public License.

Errata
------

In a previous release, I mistakenly believed that the MIT license applied to the entire Font Awesome package.
