This project adds familiar Flash-like ease-of-tweening and easing equations to WPF. It has three primary goals:

  * Be able to start an animation and assign an 'Completed' handler in one line of code
  * Have those animations set the final value of the property to the 'To' value of the animation, then disappear (i.e. if I animate the Canvas.Left property of a Rectangle from 0 to 100, I expect the Canvas.Left property to be 100 when the animation completes, and I want to be able to assign a new value directly to that property)
  * Add Robert Penner's canonical easing equations to WPF, but take full advantage of the WPF animation engine so they can be used in XAML or in code.