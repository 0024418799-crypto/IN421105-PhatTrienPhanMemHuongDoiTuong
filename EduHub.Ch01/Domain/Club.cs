namespace EduHub.Ch01.Domain;

public class Club
{
    private readonly List<Member> _members = new List<Member>();

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public IReadOnlyList<Member> Members
    {
        get { return _members; }
    }

    private Club(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
    }

    public static Club Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Tên CLB không được để trống.");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Mô tả CLB không được để trống.");
        }

        return new Club(name.Trim(), description.Trim());
    }

    public void AddMember(Member member)
    {
        if (member == null)
        {
            throw new ArgumentNullException(nameof(member));
        }


        foreach (Member existing in _members)
        {
            if (existing.Id == member.Id)
            {
                throw new InvalidOperationException("Thành viên này đã có trong CLB.");
            }
        }

        _members.Add(member);
    }

    public int MemberCount()
    {
        return _members.Count;
    }
}