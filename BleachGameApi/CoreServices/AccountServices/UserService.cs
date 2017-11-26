using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CoreRepo.IDataAccess.IAccountAccess;
using MapsAndModels.ViewModels;

namespace CoreServices.AccountServices
{
    public class UserService
    {
        private readonly IUserAccess _userAccess;
        private readonly ISessionAccess _sessionAccess;
        private readonly IMapper _mapper;

        public UserService(IUserAccess userAccess, ISessionAccess sessionAccess, IMapper mapper)
        {
            _userAccess = userAccess;
            _sessionAccess = sessionAccess;
            _mapper = mapper;
        }

        public CharacterModel UpdateCharacterPosition(CharacterModel model, string connectionId)
        {
            var session = _sessionAccess.GetByToken(model.Token);
            if (session == null) return null;
            var foundUser = _userAccess.GetById(session.UserId);
            if (foundUser == null) return null;

            foundUser.PositionX = model.PositionX;
            foundUser.PositionY = model.PositionY;
            foundUser.PositionZ = model.PositionZ;
            foundUser.FacingDirection = model.FacingDirection;

            return _mapper.Map<CharacterModel>(_userAccess.Update(foundUser));
        }

        public bool AssignConnectionId(string token, string connectionId)
        {
            var session = _sessionAccess.GetByToken(token);
            if (session == null) return false;
            var user = _userAccess.GetById(session.UserId);
            if (user == null) return false;

            user.ConnectionId = connectionId;
            user.IsOnline = true;

            return _userAccess.Update(user) != null;
        }

        public bool UnassignConnectionId(string connectionId)
        {
            var user = _userAccess.GetByConnectionId(connectionId);
            if (user == null) return false;

            user.ConnectionId = null;
            user.IsOnline = false;

            return _userAccess.Update(user) != null;
        }
    }
}
