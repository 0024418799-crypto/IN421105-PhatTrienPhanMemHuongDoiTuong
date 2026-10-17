# EduHub – Ch01

## Mô tả thiết kế domain
- 5 class: Club, Member, Event, Registration, CheckIn (xem `docs/class-diagram.md`).
- Registration là bảng nối Member ↔ Event (nhiều–nhiều).
- Encapsulation: `private set`, constructor private, factory `Create()` có kiểm tra dữ liệu.
- Trạng thái và phương thức check-in dùng enum (`RegistrationStatus`, `CheckInMethod`).
- Club giữ danh sách thành viên dạng `IReadOnlyList` để bên ngoài không sửa trực tiếp.

## Cách chạy
```bash
cd EduHub.Ch01
dotnet run
```
## Tài liệu
- [User Stories](docs/user-stories.md)
- [Class Diagram](docs/class-diagram.md)
