using Service.API;

namespace ServiceTest.FakeItems
{
    internal class MockStateCRUD : IStateCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public async Task AddState(int id, int catalogid, int quantity)
        {
            await _dataRepository.AddState(id, catalogid, quantity);
        }

        public async Task DeleteState(int id)
        {
            await _dataRepository.DeleteState(id);
        }

        public async Task<Dictionary<int, IStateDTO>> GetAllStates()
        {
            return await _dataRepository.GetAllStates();
        }

        public async Task<IStateDTO> GetState(int id)
        {
            return await _dataRepository.GetState(id);
        }

        public async Task<int> GetStatesCount()
        {
            return await _dataRepository.GetStatesCount();
        }

        public async Task UpdateState(int id, int catalogid, int quantity)
        {
            await _dataRepository.UpdateState(id, catalogid, quantity);
        }
    }
}
