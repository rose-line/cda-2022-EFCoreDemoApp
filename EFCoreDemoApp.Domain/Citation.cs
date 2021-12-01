namespace EFCoreDemoApp.Domaine
{
  public class Citation
  {
    public int Id { get; set; }
    public string Texte { get; set; }
    public Acteur Acteur { get; set; }
    public int ActeurId { get; set; }
  }
}
