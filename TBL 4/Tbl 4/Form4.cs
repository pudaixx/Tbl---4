namespace Exercicio_Windows_Forms_GitHub;

public class Form4 : Form
{
    public Form4()
    {
        Text = "Vendas";
        Size = new Size(500, 350);
        StartPosition = FormStartPosition.CenterScreen;
        Controls.Add(new Label
        {
            Text = "Formulário de Vendas",
            AutoSize = true,
            Location = new Point(30, 30)
        });
    }
}
