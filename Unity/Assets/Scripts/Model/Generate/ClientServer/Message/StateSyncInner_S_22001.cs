using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 请求匹配
    /// </summary>
    [MemoryPackable]
    [Message(StateSyncInner.G2Match_StateSyncMatch)]
    [ResponseType(nameof(Match2G_StateSyncMatch))]
    public partial class G2Match_StateSyncMatch : MessageObject, IRequest
    {
        public static G2Match_StateSyncMatch Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Match_StateSyncMatch), isFromPool) as G2Match_StateSyncMatch;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Id { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Id = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.Match2G_StateSyncMatch)]
    public partial class Match2G_StateSyncMatch : MessageObject, IResponse
    {
        public static Match2G_StateSyncMatch Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Match2G_StateSyncMatch), isFromPool) as Match2G_StateSyncMatch;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.Match2Map_StateSyncGetRoom)]
    [ResponseType(nameof(Map2Match_StateSyncGetRoom))]
    public partial class Match2Map_StateSyncGetRoom : MessageObject, IRequest
    {
        public static Match2Map_StateSyncGetRoom Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Match2Map_StateSyncGetRoom), isFromPool) as Match2Map_StateSyncGetRoom;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public List<long> PlayerIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.Map2Match_StateSyncGetRoom)]
    public partial class Map2Match_StateSyncGetRoom : MessageObject, IResponse
    {
        public static Map2Match_StateSyncGetRoom Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Map2Match_StateSyncGetRoom), isFromPool) as Map2Match_StateSyncGetRoom;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        /// <summary>
        /// 房间的ActorId
        /// </summary>
        [MemoryPackOrder(3)]
        public ActorId ActorId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.ActorId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.G2Room_StateSyncReconnect)]
    [ResponseType(nameof(Room2G_StateSyncReconnect))]
    public partial class G2Room_StateSyncReconnect : MessageObject, IRequest
    {
        public static G2Room_StateSyncReconnect Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Room_StateSyncReconnect), isFromPool) as G2Room_StateSyncReconnect;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.Room2G_StateSyncReconnect)]
    public partial class Room2G_StateSyncReconnect : MessageObject, IResponse
    {
        public static Room2G_StateSyncReconnect Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2G_StateSyncReconnect), isFromPool) as Room2G_StateSyncReconnect;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        [MemoryPackOrder(3)]
        public long StartTime { get; set; }

        [MemoryPackOrder(4)]
        public List<UnitInfo> UnitInfos { get; set; } = new();

        [MemoryPackOrder(5)]
        public int Frame { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.StartTime = default;
            this.UnitInfos.Clear();
            this.Frame = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.RoomManager2Room_StateSyncInit)]
    [ResponseType(nameof(Room2RoomManager_StateSyncInit))]
    public partial class RoomManager2Room_StateSyncInit : MessageObject, IRequest
    {
        public static RoomManager2Room_StateSyncInit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(RoomManager2Room_StateSyncInit), isFromPool) as RoomManager2Room_StateSyncInit;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public List<long> PlayerIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.Room2RoomManager_StateSyncInit)]
    public partial class Room2RoomManager_StateSyncInit : MessageObject, IResponse
    {
        public static Room2RoomManager_StateSyncInit Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Room2RoomManager_StateSyncInit), isFromPool) as Room2RoomManager_StateSyncInit;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    /// <summary>
    /// 刷新匹配信息
    /// </summary>
    [MemoryPackable]
    [Message(StateSyncInner.Match2G_StateSyncRefreshMatch)]
    [ResponseType(nameof(G2Match_StateSyncRefreshMatch))]
    public partial class Match2G_StateSyncRefreshMatch : MessageObject, IMessage
    {
        public static Match2G_StateSyncRefreshMatch Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(Match2G_StateSyncRefreshMatch), isFromPool) as Match2G_StateSyncRefreshMatch;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        /// <summary>
        /// 房间的ActorId
        /// </summary>
        [MemoryPackOrder(1)]
        public ActorId ActorId { get; set; }

        /// <summary>
        /// 房间内玩家信息
        /// </summary>
        [MemoryPackOrder(2)]
        public List<long> PlayerIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.ActorId = default;
            this.PlayerIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.G2Match_StateSyncRefreshMatch)]
    public partial class G2Match_StateSyncRefreshMatch : MessageObject, IResponse
    {
        public static G2Match_StateSyncRefreshMatch Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Match_StateSyncRefreshMatch), isFromPool) as G2Match_StateSyncRefreshMatch;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.G2Match_CancelMatch)]
    [ResponseType(nameof(Match2G_CancelMatch))]
    public partial class G2Match_CancelMatch : MessageObject, IRequest
    {
        public static G2Match_CancelMatch Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Match_CancelMatch), isFromPool) as G2Match_CancelMatch;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.G2Match_CreateRoom)]
    [ResponseType(nameof(Match2G_CreateRoom))]
    public partial class G2Match_CreateRoom : MessageObject, IRequest
    {
        public static G2Match_CreateRoom Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Match_CreateRoom), isFromPool) as G2Match_CreateRoom;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(2)]
        public string RoomName { get; set; }

        [MemoryPackOrder(3)]
        public RoomMode Mode { get; set; }

        [MemoryPackOrder(4)]
        public int MaxPlayers { get; set; }

        [MemoryPackOrder(5)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;
            this.RoomName = default;
            this.Mode = default;
            this.MaxPlayers = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.G2Match_GetRoomList)]
    [ResponseType(nameof(Match2G_GetRoomList))]
    public partial class G2Match_GetRoomList : MessageObject, IRequest
    {
        public static G2Match_GetRoomList Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Match_GetRoomList), isFromPool) as G2Match_GetRoomList;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public RoomMode Mode { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Mode = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.G2Match_JoinRoom)]
    [ResponseType(nameof(Match2G_JoinRoom))]
    public partial class G2Match_JoinRoom : MessageObject, IRequest
    {
        public static G2Match_JoinRoom Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Match_JoinRoom), isFromPool) as G2Match_JoinRoom;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        [MemoryPackOrder(2)]
        public long RoomId { get; set; }

        [MemoryPackOrder(3)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;
            this.RoomId = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(StateSyncInner.G2Match_LeaveRoom)]
    [ResponseType(nameof(Match2G_LeaveRoom))]
    public partial class G2Match_LeaveRoom : MessageObject, IRequest
    {
        public static G2Match_LeaveRoom Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2Match_LeaveRoom), isFromPool) as G2Match_LeaveRoom;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long PlayerId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PlayerId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    public static class StateSyncInner
    {
        public const ushort G2Match_StateSyncMatch = 22002;
        public const ushort Match2G_StateSyncMatch = 22003;
        public const ushort Match2Map_StateSyncGetRoom = 22004;
        public const ushort Map2Match_StateSyncGetRoom = 22005;
        public const ushort G2Room_StateSyncReconnect = 22006;
        public const ushort Room2G_StateSyncReconnect = 22007;
        public const ushort RoomManager2Room_StateSyncInit = 22008;
        public const ushort Room2RoomManager_StateSyncInit = 22009;
        public const ushort Match2G_StateSyncRefreshMatch = 22010;
        public const ushort G2Match_StateSyncRefreshMatch = 22011;
        public const ushort G2Match_CancelMatch = 22012;
        public const ushort G2Match_CreateRoom = 22013;
        public const ushort G2Match_GetRoomList = 22014;
        public const ushort G2Match_JoinRoom = 22015;
        public const ushort G2Match_LeaveRoom = 22016;
    }
}