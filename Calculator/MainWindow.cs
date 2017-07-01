using System;
using Gtk;
using Calculator;

public partial class MainWindow : Gtk.Window
{
    private CalculatorEngine Engine;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Engine = new CalculatorEngine();
        Build();
        InvalidateLabel();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    private void ButtonNumberClick(object sender, EventArgs args)
    {
        Engine.AddDigit((sender as Button).Label[0]);
        InvalidateLabel();
    }

    private void ButtonOperatorClick(object sender, EventArgs args)
    {
        Engine.SetOperator((sender as Button).Label[0]); 
        InvalidateLabel();
    }

    private void ButtonResultClick(object sender, EventArgs args)
    {
        Engine.MakeCalculation();
        InvalidateLabel();
    }

    private void ButtonDotClick(object sender, EventArgs args)
    {
        Engine.SetDot();
    }

    private void ButtonClearClick(object sender, EventArgs args)
    {
        Engine.Clear();
        InvalidateLabel();
    }
    private void InvalidateLabel()
    {
        calcLabel.Text = Engine.PrintState();
    }
}
