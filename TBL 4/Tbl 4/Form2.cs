namespace Exercicio_Windows_Forms_GitHub;

public class Form2 : Form
{
    public Form2()
    {
        Text = "Clientes";
        Size = new Size(500, 350);
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(new Label
        {
            Text = "Formulário de Clientes",
            AutoSize = true,
            Location = new Point(30, 30)
        });
    }
}
