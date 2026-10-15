using EduHub.Ch01.Domain;

Console.OutputEncoding = System.Text.Encoding.UTF8;

const string Separator = "==============================================";

void PrintStep(int number, string title)
{
    Console.WriteLine();
    Console.WriteLine(Separator);
    Console.WriteLine($"BƯỚC {number}: {title}");
    Console.WriteLine(Separator);
}

string FindMemberName(List<Member> allMembers, Guid memberId)
{
    foreach (Member member in allMembers)
    {
        if (member.Id == memberId)
        {
            return member.Name;
        }
    }
    return "(không rõ)";
}

// ---------- Tạo CLB ----------
PrintStep(1, "Tạo câu lạc bộ");
Club club = Club.Create("Tech Club", "Câu lạc bộ công nghệ dành cho sinh viên Khoa Công nghệ và Kỹ thuật");
Console.WriteLine($"Đã tạo CLB: {club.Name}");
Console.WriteLine($"Mô tả: {club.Description}");

// ---------- Thêm 3 thành viên ----------
PrintStep(2, "Thêm 3 thành viên vào CLB");
Member an = Member.Create("Nguyễn Văn An", "an@dthu.edu.vn", "DH001");
Member binh = Member.Create("Trần Thị Bình", "binh@dthu.edu.vn", "DH002");
Member cuong = Member.Create("Lê Hoàng Cường", "cuong@dthu.edu.vn", "DH003");

List<Member> allMembers = new List<Member> { an, binh, cuong };

foreach (Member member in allMembers)
{
    club.AddMember(member);
    Console.WriteLine($"+ Đã thêm: {member.Name} ({member.StudentCode})");
}
Console.WriteLine($"Tổng số thành viên: {club.MemberCount()}");

// ---------- Tạo sự kiện ----------
PrintStep(3, "Tạo sự kiện");
Event workshop = Event.Create(club.Id, "Workshop AI", DateTime.Now.AddDays(7), 50, false);
Console.WriteLine($"Sự kiện: {workshop.Title}");
Console.WriteLine($"Ngày: {workshop.Date:dd/MM/yyyy}");
Console.WriteLine($"Sức chứa: {workshop.Capacity}");

// ---------- Đăng ký và xác nhận ----------
PrintStep(4, "2 thành viên đăng ký tham dự");
List<Registration> registrations = new List<Registration>();

Member[] registrants = { an, binh };

foreach (Member member in registrants)
{
    if (!workshop.HasCapacity(registrations.Count))
    {
        Console.WriteLine("Sự kiện đã hết chỗ!");
        break;
    }

    Registration registration = Registration.Create(member.Id, workshop.Id);
    Console.WriteLine($"{member.Name} đăng ký -> Trạng thái: {registration.Status}");

    registration.Confirm();
    Console.WriteLine($"{member.Name} được xác nhận -> Trạng thái: {registration.Status}");

    registrations.Add(registration);
}

// ---------- Check-in ----------
PrintStep(5, "Một thành viên check-in");
List<CheckIn> checkIns = new List<CheckIn>();

CheckIn checkIn = CheckIn.Create(registrations[0], CheckInMethod.QrCode);
checkIns.Add(checkIn);
Console.WriteLine($"{an.Name}: {checkIn.Summary()}");

// ---------- Báo cáo tham dự ----------
PrintStep(6, "Báo cáo tham dự");
Console.WriteLine($"Sự kiện      : {workshop.Title}");
Console.WriteLine($"Số đăng ký   : {registrations.Count}");
Console.WriteLine($"Số check-in  : {checkIns.Count}");
Console.WriteLine("Danh sách đăng ký:");

foreach (Registration registration in registrations)
{
    string name = FindMemberName(allMembers, registration.MemberId);
    Console.WriteLine($"  - {name} ({registration.Status})");
}

Console.WriteLine("Danh sách đã check-in:");
foreach (CheckIn item in checkIns)
{
    foreach (Registration registration in registrations)
    {
        if (registration.Id == item.RegistrationId)
        {
            string name = FindMemberName(allMembers, registration.MemberId);
            Console.WriteLine($"  - {name}");
        }
    }
}

// ---------- Thử vi phạm luật nghiệp vụ ----------
PrintStep(7, "Thử thao tác vi phạm luật");
try
{
    Registration cancelled = Registration.Create(cuong.Id, workshop.Id);
    cancelled.Cancel();
    Console.WriteLine("Đã huỷ phiếu của Cường, bây giờ thử xác nhận lại...");
    cancelled.Confirm();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Đã bắt được lỗi nghiệp vụ: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("Chương trình kết thúc.");
