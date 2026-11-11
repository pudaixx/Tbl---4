using System.Runtime.InteropServices;

namespace Exercicio_Windows_Forms_GitHub;

public class Form1 : Form
{
    private readonly Panel painelSuperior = new();
    private readonly Panel painelLateral = new();
    private readonly Button btnMaximizar = new();
    private readonly Button btnRestaurar = new();

    public const int WM_NCLBUTTONDOWN = 0x00A1;
    public const int HT_CAPTION = 0x02;

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    public Form1()
    {
        Text = "Meu Sistema";
        Size = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.None;
        BackColor = Color.White;

        painelSuperior.Dock = DockStyle.Top;
        painelSuperior.Height = 45;
        painelSuperior.BackColor = Color.FromArgb(35, 35, 35);
        painelSuperior.MouseDown += painelSuperior_MouseDown;
        Controls.Add(painelSuperior);

        Label titulo = new()
        {
            Text = "Meu Sistema",
            ForeColor = Color.White,
            AutoSize = true,
            Location = new Point(15, 14)
        };
        painelSuperior.Controls.Add(titulo);

        Button btnFechar = CriarBotaoTitulo("X", 855);
        btnFechar.Click += (sender, e) => Close();
        painelSuperior.Controls.Add(btnFechar);

        btnMaximizar.Text = "□";
        ConfigurarBotaoTitulo(btnMaximizar, 815);
        btnMaximizar.Click += btnMaximizar_Click;
        painelSuperior.Controls.Add(btnMaximizar);

        btnRestaurar.Text = "❐";
        ConfigurarBotaoTitulo(btnRestaurar, 815);
        btnRestaurar.Visible = false;
        btnRestaurar.Click += btnRestaurar_Click;
        painelSuperior.Controls.Add(btnRestaurar);

        painelLateral.Dock = DockStyle.Left;
        painelLateral.Width = 180;
        painelLateral.BackColor = Color.FromArgb(45, 45, 48);
        Controls.Add(painelLateral);

        AdicionarBotaoMenu("Clientes", 30, () => AbrirFormNoPanel<Form2>());
        AdicionarBotaoMenu("Produtos", 90, () => AbrirFormNoPanel<Form3>());
        AdicionarBotaoMenu("Vendas", 150, () => AbrirFormNoPanel<Form4>());

        Label mensagem = new()
        {
            Text = "Selecione uma opção no menu.",
            AutoSize = true,
            Location = new Point(220, 90),
            Font = new Font("Arial", 12)
        };
        Controls.Add(mensagem);
    }

    private Button CriarBotaoTitulo(string texto, int x)
    {
        Button botao = new() { Text = texto };
        ConfigurarBotaoTitulo(botao, x);
        return botao;
    }

    private void ConfigurarBotaoTitulo(Button botao, int x)
    {
        botao.Size = new Size(40, 40);
        botao.Location = new Point(x, 2);
        botao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        botao.FlatStyle = FlatStyle.Flat;
        botao.FlatAppearance.BorderSize = 0;
        botao.ForeColor = Color.White;
        botao.BackColor = painelSuperior.BackColor;
        botao.FlatAppearance.MouseOverBackColor = Color.Gray;
    }

    private void AdicionarBotaoMenu(string texto, int y, Action acao)
    {
        Button botao = new()
        {
            Text = texto,
            Location = new Point(10, y),
            Size = new Size(160, 45),
            ForeColor = Color.White,
            BackColor = painelLateral.BackColor,
            FlatStyle = FlatStyle.Flat,
            TextAlign = ContentAlignment.MiddleCenter
        };
        botao.FlatAppearance.BorderSize = 0;
        botao.FlatAppearance.MouseOverBackColor = Color.Goldenrod;
        botao.Click += (sender, e) => acao();
        painelLateral.Controls.Add(botao);
    }

    private void btnMaximizar_Click(object? sender, EventArgs e)
    {
        WindowState = FormWindowState.Maximized;
        btnRestaurar.Visible = true;
        btnMaximizar.Visible = false;
    }

    private void btnRestaurar_Click(object? sender, EventArgs e)
    {
        WindowState = FormWindowState.Normal;
        btnRestaurar.Visible = false;
        btnMaximizar.Visible = true;
    }

    private void painelSuperior_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }

    private void AbrirFormNoPanel<Forms>() where Forms : Form, new()
    {
        Form formulario = new Forms();
        formulario.Show();
    }
}
