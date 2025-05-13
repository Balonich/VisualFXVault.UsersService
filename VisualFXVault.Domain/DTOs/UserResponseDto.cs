using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisualFXVault.Domain.DTOs;

public record UserResponseDto(Guid UserId, string? Username, string? Email, string Gender);