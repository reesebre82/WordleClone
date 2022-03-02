import Header from './components/FrontSection/Header/Header'
import SnapSection from './components/SnapSection'
import ScrollSnapScroller from './components/ScrollSnapScroller'
import ProjectContainer from './components/ProjectsSection/ProjectContainer';

function App() {

  return (
    <div className="Container">
      <ScrollSnapScroller>
        <SnapSection bgColor="cornflowerblue">
          <Header />
        </SnapSection>
        <SnapSection bgColor="white">
          <ProjectContainer />
        </SnapSection>
        <SnapSection bgColor="cornflowerblue"/>
      </ScrollSnapScroller>
    </div>
  );
}

export default App;
