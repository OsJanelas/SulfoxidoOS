import tkinter as tk
from tkinter import messagebox
import os
import time
from datetime import datetime

class SulfoxidoGUI:
    def __init__(self, root):
        self.root = root
        self.root.title("SulfoxidoOS v2.1 - GUI")
        self.root.geometry("900x600")
        self.root.configure(bg="#121212")  # Fundo Grafite Escuro

        # Cores do Sistema
        self.primary = "#ff00ff"  # Magenta
        self.secondary = "#2d2d2d" # Cinza Metal
        self.text_color = "#ffffff"

        self.create_widgets()
        self.update_clock()

    def create_widgets(self):
        # --- Barra de Tarefas Superior ---
        self.taskbar = tk.Frame(self.root, bg=self.primary, height=35)
        self.taskbar.pack(fill="x", side="top")

        self.label_title = tk.Label(self.taskbar, text=" SULFOXIDO KERNEL v2.1 ", 
                                    bg=self.primary, fg="black", font=("Consolas", 10, "bold"))
        self.label_title.pack(side="left", padx=10)

        self.label_time = tk.Label(self.taskbar, text="", bg=self.primary, fg="black", font=("Consolas", 10))
        self.label_time.pack(side="right", padx=10)

        # --- Desktop (Área Central) ---
        self.desktop = tk.Frame(self.root, bg="#121212")
        self.desktop.pack(expand=True, fill="both", padx=40, pady=40)

        # Grid de Aplicativos (Tiles)
        self.add_app_tile("NOTAS", "📝", lambda: os.system("notepad"), 0, 0)
        self.add_app_tile("ARQUIVOS", "📁", lambda: os.system("explorer ."), 0, 1)
        self.add_app_tile("CALC", "🧮", lambda: os.system("calc"), 0, 2)
        self.add_app_tile("SHELL", "📟", self.open_terminal, 1, 0)
        self.add_app_tile("SISTEMA", "⚙️", self.show_info, 1, 1)
        self.add_app_tile("SAIR", "🛑", self.root.quit, 1, 2)

        # --- Barra de Status Inferior ---
        self.statusbar = tk.Frame(self.root, bg=self.secondary, height=25)
        self.statusbar.pack(fill="x", side="bottom")
        
        self.status_msg = tk.Label(self.statusbar, text="Pronto para processamento químico...", 
                                   bg=self.secondary, fg=self.primary, font=("Consolas", 9))
        self.status_msg.pack(side="left", padx=10)

    def add_app_tile(self, name, icon, command, row, col):
        tile = tk.Button(self.desktop, text=f"{icon}\n\n{name}", 
                         bg=self.secondary, fg=self.primary, 
                         font=("Consolas", 12, "bold"),
                         width=15, height=6, relief="flat",
                         activebackground=self.primary, activeforeground="black",
                         command=command)
        tile.grid(row=row, column=col, padx=15, pady=15)

    def update_clock(self):
        now = datetime.now().strftime("%H:%M:%S")
        self.label_time.config(text=now)
        self.root.after(1000, self.update_clock)

    def open_terminal(self):
        self.status_msg.config(text="Injetando terminal de emergência...")
        os.system("start cmd /k prompt Sulfoxido-Shell$G")

    def show_info(self):
        messagebox.showinfo("SulfoxidoOS Info", "Kernel: v2.1.0\nCompilação: Python Tkinter\nStatus: Estável")

if __name__ == "__main__":
    root = tk.Tk()
    # Remove a borda padrão do Windows para parecer mais com um SO próprio (opcional)
    # root.overrideredirect(True) 
    app = SulfoxidoGUI(root)
    root.mainloop()