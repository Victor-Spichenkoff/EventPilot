/*
 * LEGACY Code
 * Needs to change 
 * 
 */


// namespace EventPilot.Application.Apply;

//
// public static class EventPatchMapping
// {
//     public static void ApplyPatch(this PatchEventDto dto, Event entity)
//     {
//         // nullables
//         if (dto.Description.HasValue)
//             entity.Description = dto.Description.Value!;
//
//         if (dto.TotalCapacity.HasValue)
//             entity.TotalCapacity = dto.TotalCapacity.Value!;
//
//
//         if (dto.Name.HasValue && dto.Name.Value != null)
//             entity.Name = dto.Name.Value!;
//
//         if (dto.Location.HasValue && dto.Location.Value != null)
//             entity.Location = dto.Location.Value!;
//
//         if (dto.TotalCapacity.HasValue && dto.TotalCapacity.Value != null)
//             entity.TotalCapacity = dto.TotalCapacity.Value!;
//
//         if (dto.StartDate.HasValue)
//             entity.StartDate = dto.StartDate.Value!;
//
//         if (dto.EndDate.HasValue)
//             entity.EndDate = dto.EndDate.Value!;
//
//         if (dto.Status.HasValue)
//             entity.Status = dto.Status.Value!;
//     }
// }