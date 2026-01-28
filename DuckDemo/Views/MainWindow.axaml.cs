using System.Collections.Generic;
using Avalonia.Controls;
using DuckDemo.Models;

namespace DuckDemo.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MallardDuck mallard = new MallardDuck();
        RedheadDuck redhead = new RedheadDuck();
        RubberDuck rubberduck = new RubberDuck();
        DecoyDuck decoyduck = new DecoyDuck();

        // Hook up button click events
        MallardButton.Click += (_, _) => ShowDuck(mallard);
        RedheadButton.Click += (_, _) => ShowDuck(redhead);
        RubberButton.Click += (_, _) => ShowDuck(rubberduck);
        DecoyButton.Click += (_, _) => ShowDuck(decoyduck);

        SetMallard.Click += (_, _) => updateDuck(mallard);
        SetRedhead.Click += (_, _) => updateDuck(redhead);
        SetRubber.Click += (_, _) => updateDuck(rubberduck);
        SetDecoy.Click += (_, _) => updateDuck(decoyduck);
    }

    // Helper method to show duck behavior in the TextBlock
    private void ShowDuck(Duck duck)
    {
        OutputTextBlock.Text = duck.Describe();
    }

    private void updateDuck(Duck duck)
    {

        Dictionary<string, TextBox[]> input = new()
        {
            {new MallardDuck().Name, [MallardDuckQuack, MallardDuckFly]},
            {new RedheadDuck().Name, [RedheadDuckQuack, RedheadDuckFly]},
            {new RubberDuck().Name, [RubberDuckQuack, RubberDuckFly]},
            {new DecoyDuck().Name, [DecoyDuckQuack, DecoyDuckFly]}
        };

        TextBox[] inputs = input[duck.Name];

        string quackInput = inputs[0].Text ?? "";
        string flyInput = inputs[1].Text ?? "";

        if (quackInput.Length >= 1)
        {
            QuackBehavior quackBeh;
            if (quackInput.Equals("Quack"))
            {
                quackBeh = new Quack();
            }
            else if (quackInput.Equals("Squeak"))
            {
                quackBeh = new Squeak();
            }
            else
            {
                quackBeh = new MuteQuack();
            }
            duck.setQuackBehavior(quackBeh);
        }
        if (flyInput.Length >= 1)
        {
            FlyBehavior flyBeh;
            if (flyInput.Equals("Wings"))
            {
                flyBeh = new FlyWithWings();
            }
            else
            {
                flyBeh = new FlyNoWings();
            }
            duck.setFlyBehavior(flyBeh);
        }
    }
}
