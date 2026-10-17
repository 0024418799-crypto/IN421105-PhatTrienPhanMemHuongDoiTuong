namespace EduHub.Ch01.Domain;

public class Member
{
   
    private bool _isActive;

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string StudentCode { get; private set; }

    public DateTime JoinedAt { get; private set; }

    private Member(string name, string email, string studentCode)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        StudentCode = studentCode;
        JoinedAt = DateTime.Now;
        _isActive = true;
    }

    public static Member Create(string name, string email, string studentCode)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Tên không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            throw new ArgumentException("Email phải chứa ký tự @.");
        }

        if (string.IsNullOrWhiteSpace(studentCode))
        {
            throw new ArgumentException("Mã số sinh viên không được để trống.");
        }

        return new Member(name.Trim(), email.Trim(), studentCode.Trim());
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}