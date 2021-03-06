﻿using System.Threading.Tasks;

namespace Todo.Services
{
    public interface IGravatar
    {
        Task<string> GetGravatarName(string hash);
        Task<string> GetGravatarImage(string hash);
        Task<Gravatar.GravatarResponse> GetProfileJson(string hash);
        string GetHash(string emailAddress);
    }
}