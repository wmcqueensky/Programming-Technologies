﻿using Service.API;

namespace ServiceTest.FakeItems
{
    internal class MockEventCRUD : IEventCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public async Task AddEvent(int id, int stateId, int employeeId, int customerid, int productid)
        {
            await _dataRepository.AddEvent(id, stateId, employeeId, customerid, productid);
        }

        public async Task DeleteEvent(int id)
        {
            await _dataRepository.DeleteEvent(id);
        }

        public async Task<Dictionary<int, IEventDTO>> GetAllEvents()
        {
            return await _dataRepository.GetAllEvents();
        }

        public async Task<IEventDTO> GetEvent(int id)
        {
            return await _dataRepository.GetEvent(id);
        }

        public async Task<int> GetEventsCount()
        {
            return await _dataRepository.GetEventsCount();
        }

        public async Task UpdateEvent(int id, int stateId, int employeeId, int customerid, int productide)
        {
            await _dataRepository.UpdateEvent(id, stateId, employeeId, customerid, productide);
        }
    }
}
